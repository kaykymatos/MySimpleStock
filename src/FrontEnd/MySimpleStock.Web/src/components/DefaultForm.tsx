import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { showAlert } from "../alerts/DefaultAlert";
import { PageLayout } from "../pages/PageLayout";
import { BaseModel } from "../types";
import { BaseService } from "../services/BaseService";
import { createFieldErrorGetter } from "../utils/createFieldErrorGetter";
import { handleApiErrors } from "../utils/errorHandler";
import { DefaultFormLayout } from "./DefaultFormLayout";

interface IInputsForm {
  label: string;
  name: string;
  id: string;
  type: string;
  errorFieldName: string;
}

interface IFormProps<T extends BaseModel> {
  id?: string;
  inputs: IInputsForm[];
  model: T;
  service: BaseService<T>;
  title: string;
  returnUrl: string;
}

export const DefaultForm = <T extends BaseModel>({
  id,
  inputs,
  model,
  service,
  title,
  returnUrl,
}: IFormProps<T>) => {
  const [formData, setFormData] = useState<T>(model);
  const [error, setError] = useState<string | null>(null);
  const [errorsMap, setErrorsMap] = useState<Record<string, string>>({});

  const resetErrors = () => {
    setError(null);
    setErrorsMap({});
  };

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const navigate = useNavigate();

  if (id) {
    useEffect(() => {
      const fetchInfo = async () => {
        try {
          const result = await service.getById(id);
          if (result !== null) setFormData(result);
          else {
            showAlert("warning", `${title} não encontrado.`);
            setError(`${title} não encontrado.`);
          }
        } catch (err) {
          showAlert("error", `Erro ao carregar ${title}.`);
          setError(`Erro ao carregar ${title}.`);
        }
      };

      fetchInfo();
    }, [id, service, title]);
  }

  const getFieldError = createFieldErrorGetter(errorsMap);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    resetErrors();
    handleApiErrors(
      () => service.create(formData),
      setErrorsMap,
      setError,
      () => navigate(`/${returnUrl}`),
      showAlert
    );
  };

  return (
    <PageLayout title={title}>
      <DefaultFormLayout title={`Envie as informações de ${title}`}>
        {error && <p className="error-text">{error}</p>}

        {inputs.map((input) => (
          <div key={input.id} className="mb-4">
            <label htmlFor={input.id} className="block mb-2 font-medium">
              {input.label}
            </label>
            <input
              type={input.type}
              id={input.id}
              name={input.name}
              value={(formData as any)[input.name] || ""}
              onChange={handleChange}
              className="w-full p-3 rounded-lg bg-gray-800 text-white focus:outline-none focus:ring-2 focus:ring-blue-500"
              placeholder={`Digite ${input.label.toLowerCase()}`}
              required
            />
            {getFieldError(input.errorFieldName) && (
              <p className="error-text text-sm">
                {getFieldError(input.errorFieldName)}
              </p>
            )}
          </div>
        ))}

        <button
          type="button"
          onClick={handleSubmit}
          className="w-full bg-blue-600 hover:bg-blue-700 text-white font-bold py-3 rounded-lg transition"
        >
          Enviar
        </button>
      </DefaultFormLayout>
    </PageLayout>
  );
};

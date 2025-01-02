import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { showAlert } from "../../alerts/DefaultAlert";
import { DefaultForm } from "../../components/DefaultForm";
import { ClientService } from "../../services/ClientService";
import { ClientModel } from "../../types";
import { IFormProps } from "../IFormProps";
import { PageLayout } from "../PageLayout";

export const ClientForm: React.FC<IFormProps> = ({ id }) => {
  const [formData, setFormData] = useState<ClientModel>(
    new ClientModel()
  );

  const [error, setError] = useState<string | null>(null);
  const [errorsMap, setErrorsMap] = useState<Record<string, string>>({});

  const clientService = new ClientService();
  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };
  const navigate = useNavigate();
  if (id) {
    useEffect(() => {
      const fetchGraphic = async () => {
        try {
          const service = new ClientService();
          const result = await service.getById(id);
          if (result !== null) setFormData(result);
          else {
            showAlert("warning", `Cliente não encontrado.`);
            setError("C não encontrado.");
          }
        } catch (err) {
          showAlert("error", `Erro ao carregar os clientes.`);
          setError("Erro ao carregar os clientes.");
        }
      };

      fetchGraphic();
    }, []);
  }

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      const response = await clientService.create(formData);

      if (!response.success && !response.isInternalError) {
        const newErrorsMap: Record<string, string> = {};
        response.errors.forEach((item: any) => {
          newErrorsMap[item.key] = item.value;
          showAlert("warning", `${item.key}:${item.value}`);
        });
        setErrorsMap(newErrorsMap);
      } else if (response.isInternalError) {
        setError("Erro interno no servidor");
      } else {
        navigate("/Clients");
      }
    } catch (error) {
      console.error("Erro ao enviar:", error);
      alert("Não foi possível enviar as informações.");
    }
  };
  const getFieldError = (field: string) => {
    return errorsMap[field] || null;
  };

  return (
    <PageLayout title="Produtos">
      <DefaultForm title="Envie as informações do produto">
        {error && <p className="error-text">{error}</p>}

        <div className="mb-4">
          <label htmlFor="nome" className="block mb-2 font-medium">
            Nome
          </label>
          <input
            type="text"
            id="name"
            name="name"
            value={formData.name}
            onChange={handleChange}
            className="w-full p-3 rounded-lg bg-gray-800 text-white focus:outline-none focus:ring-2 focus:ring-blue-500"
            placeholder="Digite seu nome"
            required
          />
          {getFieldError("Name") && (
            <p className="error-text text-sm">{getFieldError("Name")}</p>
          )}
        </div>
        <button
          type="button"
          onClick={handleSubmit}
          className="w-full bg-blue-600 hover:bg-blue-700 text-white font-bold py-3 rounded-lg transition"
        >
          Enviar
        </button>
      </DefaultForm>
    </PageLayout>
  );
};

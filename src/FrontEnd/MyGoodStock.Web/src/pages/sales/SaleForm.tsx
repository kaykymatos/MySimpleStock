import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { showAlert } from "../../alerts/DefaultAlert";
import { DefaultForm } from "../../components/DefaultForm";
import { SaleService } from "../../services/SaleService";
import { SaleModel } from "../../types";
import { PageLayout } from "../PageLayout";


export const SaleForm: React.FC = () => {
  const [formData, setFormData] = useState<SaleModel>(
    new SaleModel()
  );

  const [error, setError] = useState<string | null>(null);
  const [errorsMap, setErrorsMap] = useState<Record<string, string>>({});

  const productService = new SaleService();
  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };
  const navigate = useNavigate();
 
  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      const response = await productService.create(formData);

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
        navigate("/sales");
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
            type="date"
            id="date"
            name="date"
            value={formData.date.toDateString()}
            onChange={handleChange}
            className="w-full p-3 rounded-lg bg-gray-800 text-white focus:outline-none focus:ring-2 focus:ring-blue-500"
         
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

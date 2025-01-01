import { useState } from "react";
import { DefaultForm } from "../../components/DefaultForm";
import { ProductService } from "../../services/ProductService";
import { ProductViewModel } from "../../types";
import { PageLayout } from "../PageLayout";

export const ProductCreate = () => {
  const [formData, setFormData] = useState<ProductViewModel>({
    id: "",
    name: "",
    description: "",
    costPrice: 0,
    quantityInStock: 0,
    salePrice: 0,
    userId: "",
  } as ProductViewModel);

  const [error, setError] = useState<string | null>(null);
  const [errorsMap, setErrorsMap] = useState<Record<string, string>>({});

  const productService = new ProductService();
  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      const response = await productService.create(formData);

      if (!response.success && !response.isInternalError) {
        const newErrorsMap: Record<string, string> = {};
        response.errors.forEach((item: any) => {
          newErrorsMap[item.key] = item.value;
          showErrorToast(`${item.key}:${item.value}`);
        });
        setErrorsMap(newErrorsMap);
      } else if (response.isInternalError) {
        setError("Erro interno no servidor");
      } else {
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

        <div className="mb-4">
          <label htmlFor="description" className="block mb-2 font-medium">
            Descrição
          </label>
          <textarea
            id="description"
            name="description"
            value={formData.description}
            onChange={handleChange}
            className="w-full p-3 rounded-lg bg-gray-800 text-white focus:outline-none focus:ring-2 focus:ring-blue-500"
            placeholder="Digite sua descrição"
            rows={4}
            required
          />
          {getFieldError("Description") && (
            <p className="error-text text-sm">{getFieldError("Description")}</p>
          )}
        </div>
        <div className="mb-4">
          <label htmlFor="costPrice" className="block mb-2 font-medium">
            Preço de compra
          </label>
          <input
            type="number"
            id="costPrice"
            name="costPrice"
            value={formData.costPrice}
            onChange={handleChange}
            className="w-full p-3 rounded-lg bg-gray-800 text-white focus:outline-none focus:ring-2 focus:ring-blue-500"
            placeholder="Digite o preço de compra"
            required
          />
          {getFieldError("CostPrice") && (
            <p className="error-text text-sm">{getFieldError("CostPrice")}</p>
          )}
        </div>
        <div className="mb-4">
          <label htmlFor="salePrice" className="block mb-2 font-medium">
            Preço de venda
          </label>
          <input
            type="number"
            id="salePrice"
            name="salePrice"
            value={formData.salePrice}
            onChange={handleChange}
            className="w-full p-3 rounded-lg bg-gray-800 text-white focus:outline-none focus:ring-2 focus:ring-blue-500"
            placeholder="Digite o preço de venda"
            required
          />
          {getFieldError("SalePrice") && (
            <p className="error-text text-sm">{getFieldError("SalePrice")}</p>
          )}
        </div>

        <div className="mb-4">
          <label htmlFor="quantityInStock" className="block mb-2 font-medium">
            Preço de venda
          </label>
          <input
            type="number"
            id="quantityInStock"
            name="quantityInStock"
            value={formData.quantityInStock}
            onChange={handleChange}
            className="w-full p-3 rounded-lg bg-gray-800 text-white focus:outline-none focus:ring-2 focus:ring-blue-500"
            required
          />
          {getFieldError("QuantityInStock") && (
            <p className="error-text text-sm">
              {getFieldError("QuantityInStock")}
            </p>
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

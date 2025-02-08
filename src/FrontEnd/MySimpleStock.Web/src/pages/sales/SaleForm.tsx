import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { showAlert } from "../../alerts/DefaultAlert";
import { DefaultFormLayout } from "../../components/DefaultFormLayout";
import { SaleService } from "../../services/SaleService";
import { ClientModel, ProductModel, SaleItemModel, SaleModel } from "../../types";
import { PageLayout } from "../PageLayout";
import { ProductService } from "../../services/ProductService";
import { ClientService } from "../../services/ClientService";

export const SaleForm: React.FC = () => {
  const [formData, setFormData] = useState<SaleModel>(new SaleModel());
  const [clients, setClients] = useState<ClientModel[]>([]);
  const [products, setProducts] = useState<ProductModel[]>([]);
  const [saleItems, setSaleItems] = useState<SaleItemModel[]>([]);

  const [error, setError] = useState<string | null>(null);
  const [errorsMap, setErrorsMap] = useState<Record<string, string>>({});

  const saleService = new SaleService();
  const productService = new ProductService();
  const clientService = new ClientService();

  const navigate = useNavigate();

  useEffect(() => {
    const fetchInfo = async () => {
      try {
        const clientResult = await clientService.getAll();
        const productResult = await productService.getAll();

        if (clientResult) setClients(clientResult);
        if (productResult) setProducts(productResult);

        if (!clientResult?.length) {
          showAlert("warning", `Nenhum cliente cadastrado para efetuar uma venda.`);
          setError("Cliente não encontrado.");
        }
        if (!productResult?.length) {
          showAlert("warning", `Nenhum produto disponível para venda.`);
          setError("Produto não encontrado.");
        }
      } catch (err) {
        showAlert("error", `Erro ao carregar os dados.`);
        setError("Erro ao carregar os dados.");
      }
    };

    fetchInfo();
  }, []);

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>
  ) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleAddSaleItem = (productId: string) => {
    const product = products.find((p) => p.id === productId);
    if (product) {
      const existingItem = saleItems.find((item) => item.productId === productId);
  
      if (!existingItem) {
        const newItem: SaleItemModel = {
          ...new SaleItemModel(),
          productId,
          quantity: 1, // Quantidade padrão
          price: product.salePrice,
        };
        setSaleItems([...saleItems, newItem]);
      } else {
        showAlert("warning", "Produto já adicionado à lista.");
      }
    }
  };
  
  const handleUpdateQuantity = (productId: string, quantity: number) => {
    if (quantity < 1) {
      showAlert("warning", "A quantidade deve ser pelo menos 1.");
      return;
    }
  
    const updatedItems = saleItems.map((item) =>
      item.productId === productId ? { ...item, quantity } : item
    );
    setSaleItems(updatedItems);
  };

  const handleRemoveSaleItem = (productId: string) => {
    setSaleItems(saleItems.filter((item) => item.productId !== productId));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      const saleData: SaleModel = { ...formData, saleItems };
      const response = await saleService.create(saleData);

      if (!response.success && !response.isInternalError) {
        const newErrorsMap: Record<string, string> = {};
        response.errors.forEach((item: any) => {
          newErrorsMap[item.key] = item.value;
          showAlert("warning", `${item.key}: ${item.value}`);
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
    <PageLayout title="Registrar Venda">
      <DefaultFormLayout title="Preencha as informações da venda">
        {error && <p className="error-text">{error}</p>}

        {/* Data da venda */}
        <div className="mb-4">
          <label htmlFor="date" className="block mb-2 font-medium">
            Data da Venda
          </label>
          <input
            type="date"
            id="date"
            name="date"
            value={formData.date.toString().split("T")[0]}
            onChange={handleChange}
            className="w-full p-3 rounded-lg bg-gray-800 text-white focus:outline-none focus:ring-2 focus:ring-blue-500"
            required
          />
          {getFieldError("date") && (
            <p className="error-text text-sm">{getFieldError("date")}</p>
          )}
        </div>

        {/* Cliente */}
        <div className="mb-4">
          <label htmlFor="clientId" className="block mb-2 font-medium">
            Cliente
          </label>
          <select
            id="clientId"
            name="clientId"
            value={formData.clientId}
            onChange={handleChange}
            className="w-full p-3 rounded-lg bg-gray-800 text-white focus:outline-none focus:ring-2 focus:ring-blue-500"
          >
            <option value="">Selecione um cliente</option>
            {clients.map((client) => (
              <option key={client.id} value={client.id}>
                {client.name}
              </option>
            ))}
          </select>
          {getFieldError("clientId") && (
            <p className="error-text text-sm">{getFieldError("clientId")}</p>
          )}
        </div>

        {/* Produtos */}
        <div className="mb-4">
          <label htmlFor="products" className="block mb-2 font-medium">
            Produtos
          </label>
          <select
            id="products"
            className="w-full p-3 rounded-lg bg-gray-800 text-white focus:outline-none focus:ring-2 focus:ring-blue-500"
            onChange={(e) => handleAddSaleItem(e.target.value)} // Default quantity: 1
          >
            <option value="">Selecione um produto</option>
            {products.map((product) => (
              <option key={product.id} value={product.id}>
                {product.name} - R${product.salePrice}
              </option>
            ))}
          </select>
        </div>

       {/* Itens da venda */}
<div className="mb-4">
  <h3 className="font-medium mb-2">Itens da Venda</h3>
  {saleItems.map((item) => (
    <div
      key={item.productId}
      className="flex justify-between items-center mb-2"
    >
      <span>
        {products.find((p) => p.id === item.productId)?.name} - Preço: R${item.price}
      </span>
      <div className="flex items-center">
        <input
          type="number"
          min="1"
          value={item.quantity}
          onChange={(e) =>
            handleUpdateQuantity(item.productId, parseInt(e.target.value, 10))
          }
          className="w-16 p-2 rounded-lg bg-gray-800 text-white focus:outline-none focus:ring-2 focus:ring-blue-500 mr-2"
        />
        <button
          type="button"
          onClick={() => handleRemoveSaleItem(item.productId)}
          className="text-red-500"
        >
          Remover
        </button>
        </div>
        </div>
  ))}
        </div>

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

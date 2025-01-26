import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { DefaultButton } from "../../components/DefaultButton";
import { SaleService } from "../../services/SaleService";
import { SaleModel } from "../../types";
import { PageLayout } from "../PageLayout";
import React from "react";
import { ChevronsDown, ChevronsUp } from "lucide-react";
import { formatDate } from "../../utils/formatDate";

export const SaleList = () => {
  const [sales, setSales] = useState<SaleModel[]>([]);
  const saleService = new SaleService();
  const navigate = useNavigate();

  const [expandedRows, setExpandedRows] = useState<string[]>([]);

  const toggleRow = (id: string) => {
    setExpandedRows((prev) =>
      prev.includes(id) ? prev.filter((rowId) => rowId !== id) : [...prev, id]
    );
  };

  useEffect(() => {
    // Faz a requisição para obter todos os produtos
    const fetchSales = async () => {
      try {
        const data = await saleService.getAll();
        setSales(data);
      } catch (error) {
        console.error("Erro ao buscar produtos:", error);
      }
    };

    fetchSales();
  }, []);
  return (
    <PageLayout title="Produtos">
      <DefaultButton
        text="Novo"
        clickEvent={() => {
          navigate("/sales/create");
        }}
        buttonType="new"
      />
      <div className="table-container">
        <table className="w-full border-collapse border border-gray-200">
          <thead>
            <tr>
              <th className="border border-gray-300 px-4 py-2">Data</th>
              <th className="border border-gray-300 px-4 py-2">Cliente</th>
              <th className="border border-gray-300 px-4 py-2">Valor Total</th>
              <th className="border border-gray-300 px-4 py-2">Detalhes</th>
            </tr>
          </thead>
          <tbody>
            {sales.map((x) => (
              <React.Fragment key={x.id}>
                <tr>
                  <td className="border border-gray-300 px-4 py-2">
                    {formatDate(x.date.toString())}
                  </td>
                  <td className="border border-gray-300 px-4 py-2">
                    {x.client.name}
                  </td>
                  <td className="border border-gray-300 px-4 py-2">
                    {x.totalValue.toFixed(2)}
                  </td>
                  <td className="border border-gray-300 px-4 py-2 text-center">
                    <button
                      onClick={() => toggleRow(x.id)}
                      className="text-blue-500 hover:underline"
                    >
                      {expandedRows.includes(x.id) ? <ChevronsUp/> : <ChevronsDown/>}
                    </button>
                  </td>
                </tr>
                {expandedRows.includes(x.id) && (
                  
                  <tr>
                    <td
                      colSpan={4}
                      className="border border-gray-300 px-4 py-2"
                    >
                      <div className="bg-gray-800 p-4 rounded-md">
                        <h4 className="font-bold text-white">
                          Detalhes da Venda
                        </h4>
                        <p className="text-white">
                          <strong>Endereço:</strong> {x.client.address}, Nº{" "}
                          {x.client.number}, CEP: {x.client.cep}
                        </p>
                        <h5 className="font-bold mt-2 text-white">
                          Itens Comprados:
                        </h5>
                        <ul className="list-disc pl-6 text-white">
                          {x.saleItems.map((item) => (
                            <li key={item.id}>
                               Produto:{" "}
                               {item.product.name} |
                               Quantidade:{" "}
                              {item.quantity} | 
                              Preço: R${" "}
                              {item.price.toFixed(2)}
                            </li>
                          ))}
                        </ul>
                      </div>
                    </td>
                  </tr>
                )}
              </React.Fragment>
            ))}
          </tbody>
        </table>
      </div>
    </PageLayout>
  );
};

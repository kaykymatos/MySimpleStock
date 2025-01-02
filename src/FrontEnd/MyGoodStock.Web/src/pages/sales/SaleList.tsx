import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { DefaultButton } from "../../components/DefaultButton";
import { SaleService } from "../../services/SaleService";
import { SaleModel } from "../../types";
import { PageLayout } from "../PageLayout";

export const SaleList = () => {
  const [sales, setSales] = useState<SaleModel[]>([]);
  const saleService = new SaleService();
  const navigate = useNavigate();
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
        <table>
          <thead>
            <tr>
              <th>Data</th>
              <th>Cliente</th>
              <th>Valor Total</th>
            </tr>
          </thead>
          <tbody>
            {sales.map((x) => (
              <tr key={x.id}>
                <td>{x.date.toDateString()}</td>
                <td>{x.clientId}</td>
                <td>{x.totalValue}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </PageLayout>
  );
};

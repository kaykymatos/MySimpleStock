import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { DefaultButton } from "../../components/DefaultButton";
import { ClientService } from "../../services/ClientService";
import { ClientViewModel } from "../../types";
import { PageLayout } from "../PageLayout";

export const ClientList = () => {
  const [clients, setClients] = useState<ClientViewModel[]>([]);
  const clientService = new ClientService();
 const navigate = useNavigate();
  useEffect(() => {
    // Faz a requisição para obter todos os produtos
    const fetchClients = async () => {
      try {
        const data = await clientService.getAll();
        setClients(data);
      } catch (error) {
        console.error("Erro ao buscar produtos:", error);
      }
    };

    fetchClients();
  }, []);
  return (
    <PageLayout title="Clientes">
     <DefaultButton
        text="Novo"
        clickEvent={() => {
          navigate("/clients/create");
        }}
        buttonType="new"
      />
      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>Nome</th>
              <th>Cep</th>
              <th>Endereço</th>
              <th>Número</th>
            </tr>
          </thead>
          <tbody>
            {clients.map((x) => (
              <tr key={x.id}>
                <td>{x.name}</td>
                <td>{x.cep}</td>
                <td>{x.address}</td>
                <td>{x.number}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </PageLayout>
  );
};

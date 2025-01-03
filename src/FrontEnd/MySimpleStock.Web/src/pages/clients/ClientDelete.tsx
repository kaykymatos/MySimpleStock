import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { showAlert } from "../../alerts/DefaultAlert";
import { ClientService } from "../../services/ClientService";
import { ClientModel } from "../../types";
import { PageLayout } from "../PageLayout";
import { ItemDetailsLayout } from "../ItemDetailsLayout";

export const ClientDelete = () => {
  const [item, setItem] = useState<ClientModel | null>(null);
  const { id } = useParams();
  const navigate = useNavigate()
  const service = new ClientService();
  useEffect(() => {
    const fetchInfo = async () => {
      try {
        const result = await service.getById(id!);
        if (result !== null) setItem(result);
        else {
          showAlert("warning", `Produto não encontrado.`);
        }
      } catch (err) {
        showAlert("error", `Erro ao carregar os produtos.`);
      }
    };

    fetchInfo();
  }, []);

  const handleDelete = async () => {
    if (!item) return;

    const deleteItem = await service.delete(id!);
    if (!deleteItem.success && !deleteItem.isInternalError) {
      if (deleteItem.errors.length > 0) {
        deleteItem.errors.forEach((x) => {
          showAlert("error", x.message);
        });
      }
    }if(deleteItem.isInternalError){
        showAlert("error", deleteItem.internalErrorMessage);
      }else{
        showAlert("success", "Item deletado com sucesso!");
        navigate("Clients")
      }
  };
  const itens = {
    Nome: item?.name,
    'Cep': item?.cep,
    'Endereço': item?.address,
    'Número': item?.number
  };
  return (
    <PageLayout title="Clientes" >
      <div>
        <p className="mb-2">Você está prestes a excluir o seguinte item:</p>
        
        <ItemDetailsLayout itens={itens} />
        <div className="flex justify-center gap-4">
          <button
            className="bg-red-600 hover:bg-red-700 text-white font-bold py-2 px-4 rounded"
            onClick={handleDelete}
          >
            Excluir
          </button>
          <button
            className="bg-gray-600 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded"
            onClick={() =>   navigate("Clients")}
          >
            Cancelar
          </button>
        </div>
      </div>
    </PageLayout>
  );
};

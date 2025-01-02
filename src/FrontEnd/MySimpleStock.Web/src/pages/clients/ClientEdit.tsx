import { useParams } from "react-router-dom";
import { ClientForm } from "./ClientForm";

export const ClientEdit = () => {
  const { id } = useParams();
  return <ClientForm id={id} />;
};

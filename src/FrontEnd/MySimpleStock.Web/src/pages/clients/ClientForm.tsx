import { DefaultForm } from "../../components/DefaultForm";
import { ClientService } from "../../services/ClientService";
import { ClientModel } from "../../types";
import { IFormProps } from "../IFormProps";

export const ClientForm: React.FC<IFormProps> = ({ id }) => {
  
  return (
    <DefaultForm
    id={id}
      returnUrl="clients"
      model={new ClientModel()}
      service={new ClientService()}
      title="Clientes"
      inputs={[
        {
          id: "name",
          label: "Nome",
          name: "name",
          type: "text",
          errorFieldName: "Name",
        },
        {
          id: "address",
          label: "Endereço",
          name: "address",
          type: "text",
          errorFieldName: "Address",
        },
        {
          id: "cep",
          label: "Cep",
          name: "cep",
          type: "text",
          errorFieldName: "Cep",
        },
        {
          id: "number",
          label: "Numero",
          name: "number",
          type: "text",
          errorFieldName: "Number",
        },
      ]}
    />
    
  );
};

import { DefaultForm } from "../../components/DefaultForm";
import { ProductService } from "../../services/ProductService";
import { ProductModel } from "../../types";
import { IFormProps } from "../IFormProps";

export const ProductForm: React.FC<IFormProps> = ({ id }) => {
  
  return (
    <DefaultForm
      id={id}
      returnUrl="products"
      model={new ProductModel()}
      service={new ProductService()}
      title="Produtos"
      inputs={[
        {
          id: "name",
          label: "Nome",
          name: "name",
          type: "text",
          errorFieldName: "Name",
        },
        {
          id: "description",
          label: "Descrição",
          name: "description",
          type: "text",
          errorFieldName: "Description",
        },
        {
          id: "costPrice",
          label: "Preço de compra",
          name: "costPrice",
          type: "number",
          errorFieldName: "CostPrice",
        },
        {
          id: "salePrice",
          label: "Preço de venda",
          name: "salePrice",
          type: "number",
          errorFieldName: "SalePrice",
        },
        {
          id: "quantityInStock",
          label: "Quantidade em estoque",
          name: "quantityInStock",
          type: "number",
          errorFieldName: "QuantityInStock",
        },
      ]}
    />
  );
};

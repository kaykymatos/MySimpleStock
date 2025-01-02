import { useParams } from "react-router-dom";
import { ProductForm } from "./ProductForm";

export const ProductEdit = () => {
  const { id } = useParams();
  return <ProductForm id={id} />;
};

import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { DefaultButton } from "../../components/DefaultButton";
import { ProductService } from "../../services/ProductService";
import { ProductModel } from "../../types";
import { PageLayout } from "../PageLayout";
export const ProductList = () => {
  const [products, setProducts] = useState<ProductModel[]>([]);
  const productService = new ProductService();
  const navigate = useNavigate();
  useEffect(() => {
    // Faz a requisição para obter todos os produtos
    const fetchProducts = async () => {
      try {
        const data = await productService.getAll();
        setProducts(data);
      } catch (error) {
        console.error("Erro ao buscar produtos:", error);
      }
    };

    fetchProducts();
  }, []);

  return (
    <PageLayout title="Produtos">
      <DefaultButton
        text="Novo"
        clickEvent={() => {
          navigate("/products/create");
        }}
        buttonType="new"
      />
      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>Nome</th>
              <th>Descrição</th>
              <th>Preço</th>
              <th>Preço de venda</th>
              <th>Qauntidade em estoque</th>
            </tr>
          </thead>
          <tbody>
            {products.map((x) => (
              <tr key={x.id}>
                <td>{x.name}</td>
                <td>{x.description}</td>
                <td>{x.costPrice}</td>
                <td>{x.salePrice}</td>
                <td>{x.quantityInStock}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </PageLayout>
  );
};

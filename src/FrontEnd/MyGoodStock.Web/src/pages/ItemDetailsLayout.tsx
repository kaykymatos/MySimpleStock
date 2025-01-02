interface KeyValueData {
    [key: string]: any;
  }
  
  interface ItemDetailsLayoutProps {
    itens: KeyValueData;  // Espera um objeto com chaves e valores do tipo string
  }
  
  export const ItemDetailsLayout: React.FC<ItemDetailsLayoutProps> = ({ itens }) => {
  return (
    <div className="mb-6 p-4 bg-gray-800 text-left rounded">
      {Object.entries(itens).map(([key, value]) => (
        <div key={key}>
          <p className="text-3xl">
          <strong>{key}:</strong> {value}
          </p>
        </div>
      ))}
    </div>
  );
};

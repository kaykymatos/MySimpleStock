export const DefaultButton = ({ text, clickEvent, buttonType }: { text: string; clickEvent: () => void,buttonType:'new'|'edit'|'details'|'delete' }) => {
    const getButtonColor = () => {
        switch (buttonType) {
            case 'new':
                return 'bg-blue-700 hover:bg-blue-600 focus:ring-blue-500'; // Azul escuro para "Novo"
              case 'edit':
                return 'bg-yellow-600 hover:bg-yellow-500 focus:ring-yellow-400'; // Amarelo quente para "Editar"
              case 'details':
                return 'bg-gray-700 hover:bg-gray-600 focus:ring-gray-500'; // Cinza escuro para "Detalhes"
              case 'delete':
                return 'bg-red-700 hover:bg-red-600 focus:ring-red-500'; // Vermelho escuro para "Excluir"
              default:
                return 'bg-gray-800 hover:bg-gray-700 focus:ring-gray-600'; // Cor padrão
        }
      };
    return (
      <div className="text-right pr-3">
        <button
          onClick={clickEvent}
          className={`border-2 text-white px-4 mb-1 py-1 rounded-lg focus:outline-none focus:ring-2 transition ${getButtonColor()}`}
        >
          {text}
        </button>
      </div>
    );
  };
  
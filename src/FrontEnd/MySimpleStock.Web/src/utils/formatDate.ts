export const formatDate = (dateString:string) => {
    const date = new Date(dateString);
    const day = String(date.getDate()).padStart(2, '0'); // Adiciona zero à esquerda se necessário
    const month = String(date.getMonth() + 1).padStart(2, '0'); // Meses começam do 0, então adicionamos 1
    const year = date.getFullYear();
  
    return `${day}/${month}/${year}`;
  };
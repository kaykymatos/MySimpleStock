import { Dispatch, SetStateAction } from "react";
import { BaseModel, ResponseApiModel } from "../types";

export const handleApiErrors = async <T extends BaseModel>(
    apiCall: () => Promise<ResponseApiModel<T>>,
    setErrorsMap: Dispatch<SetStateAction<Record<string, string>>>,
    setError: Dispatch<SetStateAction<string | null>>,
    onSuccess: () => void,
    showAlert: (type: "warning" | "error", message: string) => void
  ) => {
    setErrorsMap({});
    setError(null);
  
    try {
      const response = await apiCall();
  
      if (!response.success && !response.isInternalError) {
        const newErrorsMap: Record<string, string> = {};
        response.errors.forEach((item:any) => {
          newErrorsMap[item.key] = item.value;
          showAlert("warning", `${item.key}: ${item.value}`);
        });
        setErrorsMap(newErrorsMap);
      } else if (response.isInternalError) {
        setError("Erro interno no servidor");
        showAlert("error", "Erro interno no servidor");
      } else {
        onSuccess();
      }
    } catch (error) {
      setError("Erro interno no servidor");
      showAlert("error", "Não foi possível enviar as informações, erro interno no servidor");
    }
  };
export const createFieldErrorGetter = (errorsMap: Record<string, string>) => {
  return (field: string): string | null => {
    return errorsMap[field] || null;
  };
};

export const DefaultForm = ({
  children,
  title
}: {
  children: React.ReactNode;
  title: string;
}) => {
  return (
    <form
      className="bg-white/10 backdrop-blur-lg p-6 rounded-2xl shadow-xl text-white max-w-md mx-auto"
    >
      <h2 className="text-2xl font-bold mb-4">
       {title}
      </h2>
      {children}
    </form>
  );
};

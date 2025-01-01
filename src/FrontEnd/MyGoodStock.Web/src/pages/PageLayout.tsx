import { motion } from "framer-motion";

interface IDefaultLayoutProps{
  title: string;
  children: React.ReactNode;

}

export const PageLayout = ({
  title,
  children,
}: IDefaultLayoutProps) => {
  return (
    <div className="space-y-6">
      <motion.div
        initial={{ opacity: 0, y: 20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ delay: 0.2 }}
        className="backdrop-blur-lg bg-white/5 p-6 rounded-xl border border-white/10"
      >
        <h2 className="text-xl font-semibold mb-4">{title}</h2>
        <div className="min-h-[400px]">{children}</div>
      </motion.div>
    </div>
  );
};

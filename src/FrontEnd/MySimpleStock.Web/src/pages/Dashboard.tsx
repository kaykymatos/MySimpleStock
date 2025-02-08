import React, { FC, useEffect, useState } from "react";
import { motion } from "framer-motion";
import {
  Package,
  TrendingUp,
  AlertTriangle,
  DollarSign,
  ArrowUpRight,
  ArrowDownRight,
} from "lucide-react";
import {
  AreaChart,
  Area,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  ResponsiveContainer,
} from "recharts";
import { MonthlyProfitReport as MonthlyProfitReportService } from "../services/MonthlyProfitReport";
import { MonthlyProfitReportModel, ProductModel, SaleModel } from "../types";
import { ProductService } from "../services/ProductService";
import { SaleService } from "../services/SaleService";

const data = [
  { name: "Jan", value: 400 },
  { name: "Feb", value: 300 },
  { name: "Mar", value: 600 },
  { name: "Apr", value: 800 },
  { name: "May", value: 700 },
  { name: "Jun", value: 900 },
];

interface StatCardProps {
  icon: React.ComponentType<React.SVGProps<SVGSVGElement>>; // Define o tipo do ícone como um componente React que aceita props SVG
  title: string;
  value: string | number;
  trend: "up" | "down";
  trendValue: string | number;
}

const StatCard: FC<StatCardProps> = ({
  icon: Icon,
  title,
  value,
  trend,
  trendValue,
}) => (
  <motion.div
    initial={{ opacity: 0, y: 20 }}
    animate={{ opacity: 1, y: 0 }}
    className="backdrop-blur-lg bg-white/5 p-6 rounded-xl border border-white/10"
  >
    <div className="flex justify-between">
      <div className="p-2 bg-white/10 rounded-lg">
        <Icon className="h-6 w-6 text-blue-400" />
      </div>
      <span
        className={`flex items-center gap-1 text-sm ${
          trend === "up" ? "text-green-400" : "text-red-400"
        }`}
      >
        {trend === "up" ? (
          <ArrowUpRight className="h-4 w-4" />
        ) : (
          <ArrowDownRight className="h-4 w-4" />
        )}
        {trendValue}
      </span>
    </div>
    <h3 className="mt-4 text-2xl font-semibold text-white">{value}</h3>
    <p className="text-gray-400 text-sm">{title}</p>
  </motion.div>
);

export default function Dashboard() {
  const [monthlyProfitReport, setMonthlyProfitReport] =
    useState<MonthlyProfitReportModel | null>(null);
  const [products, setProducts] = useState<ProductModel[] | null>(null);
  const [sales, setSales] = useState<SaleModel[] | null>(null);

  const monthlyProfitReportService = new MonthlyProfitReportService();
  const productService = new ProductService();
  const saleService = new SaleService();
  useEffect(() => {
    // Faz a requisição para obter todos os produtos
    const fetchProducts = async () => {
      try {
        var dataAtual = new Date();
        const month = Number(String(dataAtual.getMonth() + 1).padStart(2, "0"));
        const year = dataAtual.getFullYear();

        const report = await monthlyProfitReportService.getByMonthAndYear(
          month,
          year
        );
        const productsAPi = await productService.getAll();
        const salesApi = await saleService.getAll();

        setMonthlyProfitReport(report);

        setProducts(productsAPi);

        setSales(
          salesApi.filter((x) => {
            const creationDate = new Date(x.creationDate);
            return (
              Number(String(creationDate.getMonth() + 1).padStart(2, "0")) ===
                month && creationDate.getFullYear() === year
            );
          })
        );
      } catch (error) {
        console.error("Erro ao buscar produtos:", error);
      }
    };

    fetchProducts();
  }, []);
  const lowStockItems = products
    ? products.filter((p) => p.quantityInStock < 5).length
    : 0;
  const totalProducts = products ? products.length : 1; // Evita divisão por zero
  const lowStockPercentage = ((lowStockItems / totalProducts) * 100).toFixed(1); // Mantém uma casa decimal

  return (
    <div className="space-y-6">
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
        <StatCard
          icon={Package}
          title="Total Products"
          value={products ? products?.length : 0}
          trend="up"
          trendValue="12.5%"
        />
        <StatCard
          icon={AlertTriangle}
          title="Low Stock Items"
          value={lowStockItems}
          trend="down"
          trendValue={`${lowStockPercentage}%`}
        />

        <StatCard
          icon={TrendingUp}
          title="Monthly Sales"
          value={sales ? sales?.length : 0}
          trend="up"
          trendValue="8.1%"
        />
        <StatCard
          icon={DollarSign}
          title="Revenue"
          value={
            monthlyProfitReport
              ? monthlyProfitReport?.totalProfit.toFixed(2)
              : 0
          }
          trend="up"
          trendValue="15.3%"
        />
      </div>

      <motion.div
        initial={{ opacity: 0, y: 20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ delay: 0.2 }}
        className="backdrop-blur-lg bg-white/5 p-6 rounded-xl border border-white/10"
      >
        <h2 className="text-xl font-semibold mb-4">Stock Overview</h2>
        <div className="h-[400px]">
          <ResponsiveContainer width="100%" height="100%">
            <AreaChart data={data}>
              <defs>
                <linearGradient id="colorValue" x1="0" y1="0" x2="0" y2="1">
                  <stop offset="5%" stopColor="#3B82F6" stopOpacity={0.3} />
                  <stop offset="95%" stopColor="#3B82F6" stopOpacity={0} />
                </linearGradient>
              </defs>
              <CartesianGrid
                strokeDasharray="3 3"
                stroke="rgba(255,255,255,0.1)"
              />
              <XAxis dataKey="name" stroke="rgba(255,255,255,0.5)" />
              <YAxis stroke="rgba(255,255,255,0.5)" />
              <Tooltip
                contentStyle={{
                  backgroundColor: "rgba(0,0,0,0.8)",
                  border: "1px solid rgba(255,255,255,0.1)",
                  borderRadius: "8px",
                }}
              />
              <Area
                type="monotone"
                dataKey="value"
                stroke="#3B82F6"
                fillOpacity={1}
                fill="url(#colorValue)"
              />
            </AreaChart>
          </ResponsiveContainer>
        </div>
      </motion.div>
    </div>
  );
}

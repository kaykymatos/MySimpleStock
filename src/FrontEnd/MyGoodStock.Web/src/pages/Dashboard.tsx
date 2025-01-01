import React, { FC } from 'react';
import { motion } from 'framer-motion';
import { 
  Package, 
  TrendingUp, 
  AlertTriangle, 
  DollarSign,
  ArrowUpRight,
  ArrowDownRight
} from 'lucide-react';
import { 
  AreaChart, 
  Area, 
  XAxis, 
  YAxis, 
  CartesianGrid, 
  Tooltip,
  ResponsiveContainer 
} from 'recharts';

const data = [
  { name: 'Jan', value: 400 },
  { name: 'Feb', value: 300 },
  { name: 'Mar', value: 600 },
  { name: 'Apr', value: 800 },
  { name: 'May', value: 700 },
  { name: 'Jun', value: 900 },
];

interface StatCardProps {
  icon: React.ComponentType<React.SVGProps<SVGSVGElement>>; // Define o tipo do ícone como um componente React que aceita props SVG
  title: string;
  value: string | number;
  trend: "up" | "down";
  trendValue: string | number;
}

const StatCard: FC<StatCardProps> = ({ icon: Icon, title, value, trend, trendValue }) => (
  <motion.div
    initial={{ opacity: 0, y: 20 }}
    animate={{ opacity: 1, y: 0 }}
    className="backdrop-blur-lg bg-white/5 p-6 rounded-xl border border-white/10"
  >
    <div className="flex justify-between">
      <div className="p-2 bg-white/10 rounded-lg">
        <Icon className="h-6 w-6 text-blue-400" />
      </div>
      <span className={`flex items-center gap-1 text-sm ${trend === 'up' ? 'text-green-400' : 'text-red-400'}`}>
        {trend === 'up' ? <ArrowUpRight className="h-4 w-4" /> : <ArrowDownRight className="h-4 w-4" />}
        {trendValue}
      </span>
    </div>
    <h3 className="mt-4 text-2xl font-semibold text-white">{value}</h3>
    <p className="text-gray-400 text-sm">{title}</p>
  </motion.div>
);

export default function Dashboard() {
  return (
    <div className="space-y-6">
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
        <StatCard
          icon={Package}
          title="Total Products"
          value="2,345"
          trend="up"
          trendValue="12.5%"
        />
        <StatCard
          icon={AlertTriangle}
          title="Low Stock Items"
          value="15"
          trend="down"
          trendValue="3.2%"
        />
        <StatCard
          icon={TrendingUp}
          title="Monthly Sales"
          value="$45,678"
          trend="up"
          trendValue="8.1%"
        />
        <StatCard
          icon={DollarSign}
          title="Revenue"
          value="$123,456"
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
                  <stop offset="5%" stopColor="#3B82F6" stopOpacity={0.3}/>
                  <stop offset="95%" stopColor="#3B82F6" stopOpacity={0}/>
                </linearGradient>
              </defs>
              <CartesianGrid strokeDasharray="3 3" stroke="rgba(255,255,255,0.1)" />
              <XAxis dataKey="name" stroke="rgba(255,255,255,0.5)" />
              <YAxis stroke="rgba(255,255,255,0.5)" />
              <Tooltip 
                contentStyle={{ 
                  backgroundColor: 'rgba(0,0,0,0.8)', 
                  border: '1px solid rgba(255,255,255,0.1)',
                  borderRadius: '8px'
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
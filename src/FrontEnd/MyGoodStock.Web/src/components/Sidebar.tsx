import { motion } from 'framer-motion';
import {
  LayoutDashboard,
  List,
  Package,
  PersonStanding,
  TrendingUp
} from 'lucide-react';
import { NavLink } from 'react-router-dom';

const menuItems = [
  { icon: LayoutDashboard, label: 'Dashboard', path: '/' },
  { icon: Package, label: 'Produtos', path: '/products' },
  { icon: PersonStanding, label: 'Clientes', path: '/clients' },
  { icon: List, label: 'Vendas', path: '/sales' },
  { icon: TrendingUp, label: 'Relatórios', path: '/reports' },
];

export default function Sidebar() {
  return (
    <motion.aside 
      className="w-64 h-[calc(100vh-4rem)] backdrop-blur-md bg-white/5 border-r border-white/10 p-4"
      initial={{ x: -100, opacity: 0 }}
      animate={{ x: 0, opacity: 1 }}
      transition={{ duration: 0.5 }}
    >
      <nav className="space-y-2">
        {menuItems.map((item) => (
          <NavLink
            key={item.path}
            to={item.path}
            className={({ isActive }) =>
              `flex items-center gap-3 px-4 py-3 rounded-lg transition-all ${
                isActive
                  ? 'bg-blue-500/20 text-blue-400'
                  : 'hover:bg-white/5 text-gray-300 hover:text-white'
              }`
            }
          >
            <item.icon className="h-5 w-5" />
            <span>{item.label}</span>
          </NavLink>
        ))}
      </nav>
    </motion.aside>
  );
}
import React from 'react';
import { NavLink } from 'react-router-dom';
import { 
  LayoutDashboard, 
  Package, 
  Users, 
  TrendingUp,
  Settings,
  Truck,
  History,
  AlertCircle
} from 'lucide-react';
import { motion } from 'framer-motion';

const menuItems = [
  { icon: LayoutDashboard, label: 'Dashboard', path: '/' },
  { icon: Package, label: 'Inventory', path: '/inventory' },
  { icon: Truck, label: 'Suppliers', path: '/suppliers' },
  { icon: History, label: 'Transactions', path: '/transactions' },
  { icon: TrendingUp, label: 'Analytics', path: '/analytics' },
  { icon: AlertCircle, label: 'Alerts', path: '/alerts' },
  { icon: Users, label: 'Users', path: '/users' },
  { icon: Settings, label: 'Settings', path: '/settings' },
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
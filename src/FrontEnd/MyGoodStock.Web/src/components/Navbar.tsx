import React from 'react';
import { Bell, Search, Sun, Moon, User } from 'lucide-react';
import { motion } from 'framer-motion';

export default function Navbar() {
  const [darkMode, setDarkMode] = React.useState(false);

  return (
    <motion.nav 
      className="backdrop-blur-md bg-white/10 border-b border-white/20 px-6 py-4"
      initial={{ y: -20, opacity: 0 }}
      animate={{ y: 0, opacity: 1 }}
    >
      <div className="flex items-center justify-between">
        <div className="flex items-center gap-4">
          <h1 className="text-2xl font-bold bg-gradient-to-r from-blue-400 to-cyan-300 bg-clip-text text-transparent">
            StockVision
          </h1>
          <div className="relative">
            <input
              type="text"
              placeholder="Search..."
              className="pl-10 pr-4 py-2 rounded-lg bg-white/5 border border-white/10 focus:border-blue-400 focus:ring-1 focus:ring-blue-400 outline-none transition-all"
            />
            <Search className="absolute left-3 top-2.5 h-5 w-5 text-gray-400" />
          </div>
        </div>
        
        <div className="flex items-center gap-6">
          <button className="relative hover:text-blue-400 transition-colors">
            <Bell className="h-6 w-6" />
            <span className="absolute -top-1 -right-1 h-4 w-4 bg-red-500 rounded-full text-xs flex items-center justify-center">
              3
            </span>
          </button>
          
          <button
            onClick={() => setDarkMode(!darkMode)}
            className="hover:text-blue-400 transition-colors"
          >
            {darkMode ? <Moon className="h-6 w-6" /> : <Sun className="h-6 w-6" />}
          </button>
          
          <div className="flex items-center gap-3">
            <span className="text-sm">John Doe</span>
            <button className="h-10 w-10 rounded-full bg-white/10 flex items-center justify-center hover:bg-white/20 transition-colors">
              <User className="h-6 w-6" />
            </button>
          </div>
        </div>
      </div>
    </motion.nav>
  );
}
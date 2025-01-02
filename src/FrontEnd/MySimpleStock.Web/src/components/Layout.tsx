import { motion } from 'framer-motion';
import React from 'react';
import Navbar from './Navbar';
import Sidebar from './Sidebar';

interface ILayoutPaginasProps {
  children: React.ReactNode;
}

export default function Layout({ children }: ILayoutPaginasProps) {
  return (
    <div className="min-h-screen bg-gradient-to-br from-gray-900 to-blue-900 text-white">
      <Navbar />
      <div className="flex">
        <Sidebar />
        <motion.main 
          className="flex-1 p-8"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5 }}
        >
          <div className="backdrop-blur-lg bg-white/10 rounded-2xl p-6 shadow-xl">
          {children}
          </div>
        </motion.main>
      </div>
    </div>
  );
}
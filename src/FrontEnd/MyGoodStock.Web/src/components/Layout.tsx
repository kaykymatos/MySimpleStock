import React from 'react';
import { motion } from 'framer-motion';
import { Outlet } from 'react-router-dom';
import Sidebar from './Sidebar';
import Navbar from './Navbar';

export default function Layout() {
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
            <Outlet />
          </div>
        </motion.main>
      </div>
    </div>
  );
}
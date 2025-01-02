import React from 'react';
import { motion } from 'framer-motion';
import { Lock, Mail } from 'lucide-react';

export default function Login() {
  return (
    <div className="min-h-screen bg-gradient-to-br from-gray-900 to-blue-900 flex items-center justify-center p-4">
      <motion.div
        initial={{ opacity: 0, y: 20 }}
        animate={{ opacity: 1, y: 0 }}
        className="w-full max-w-md backdrop-blur-lg bg-white/10 p-8 rounded-2xl shadow-xl"
      >
        <div className="text-center mb-8">
          <h1 className="text-3xl font-bold text-white mb-2">Welcome Back</h1>
          <p className="text-blue-200">Sign in to access your dashboard</p>
        </div>

        <form className="space-y-6">
          <div>
            <label className="block text-blue-200 mb-2">Email</label>
            <div className="relative">
              <input
                type="email"
                className="w-full bg-white/5 border border-white/10 rounded-lg px-4 py-3 pl-12 text-white placeholder-gray-400 focus:border-blue-400 focus:ring-1 focus:ring-blue-400 outline-none transition-all"
                placeholder="Enter your email"
              />
              <Mail className="absolute left-4 top-3.5 h-5 w-5 text-gray-400" />
            </div>
          </div>

          <div>
            <label className="block text-blue-200 mb-2">Password</label>
            <div className="relative">
              <input
                type="password"
                className="w-full bg-white/5 border border-white/10 rounded-lg px-4 py-3 pl-12 text-white placeholder-gray-400 focus:border-blue-400 focus:ring-1 focus:ring-blue-400 outline-none transition-all"
                placeholder="Enter your password"
              />
              <Lock className="absolute left-4 top-3.5 h-5 w-5 text-gray-400" />
            </div>
          </div>

          <div className="flex items-center justify-between text-sm">
            <label className="flex items-center text-blue-200">
              <input type="checkbox" className="mr-2" />
              Remember me
            </label>
            <a href="#" className="text-blue-400 hover:text-blue-300">
              Forgot password?
            </a>
          </div>

          <button
            type="submit"
            className="w-full bg-blue-500 hover:bg-blue-600 text-white py-3 rounded-lg transition-colors font-medium"
          >
            Sign In
          </button>
        </form>
      </motion.div>
    </div>
  );
}
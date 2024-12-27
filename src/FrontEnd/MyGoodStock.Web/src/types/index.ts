export interface User {
  id: string;
  email: string;
  full_name: string;
  avatar_url?: string;
  role: 'admin' | 'user';
}

export interface Product {
  id: string;
  name: string;
  sku: string;
  description: string;
  quantity: number;
  min_quantity: number;
  price: number;
  category: string;
  supplier_id: string;
  created_at: string;
  updated_at: string;
}

export interface Supplier {
  id: string;
  name: string;
  email: string;
  phone: string;
  address: string;
}

export interface Transaction {
  id: string;
  product_id: string;
  type: 'in' | 'out';
  quantity: number;
  date: string;
  user_id: string;
  notes?: string;
}
import axios from 'axios';

export const ApiConfig = (endpoint:string) => {
  return axios.create({
    baseURL: `${import.meta.env.VITE_BASE_URL}/${endpoint}`,
  });
};
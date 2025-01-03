import { BaseModel, ResponseApiModel } from "../types";
import { ApiConfig } from "./ApiConfig";

export class BaseService<T extends BaseModel> {
  private endpoint: string;

  constructor(endpoint: string) {
    this.endpoint = endpoint;
  }

  async getAll(): Promise<T[]> {
    try {
      const response = await ApiConfig(this.endpoint).get<T[]>("");
      return response.data;
    } catch (error) {
      return [];
    }
  }

  async getById(id: string): Promise<T | null> {
    try {
      const response = await ApiConfig(this.endpoint).get<T>(`/${id}`);
      return response.data;
    } catch (error) {
      return null;
    }
  }

  async create(model: T): Promise<ResponseApiModel<T>> {
    try {
      const response = await ApiConfig(this.endpoint).post<ResponseApiModel<T>>(
        "",
        model
      );
      return response.data;
    } catch (error: any) {
      if (error.response.status == 400) {
        return error.response.data;
      } else {
        var res = new ResponseApiModel<T>();
        res.errors = [];
        res.internalErrorMessage = "" + error;
        res.isInternalError = true;
        res.statusCode = 500;
        res.success = false;
        return res;
      }
    }
  }

  async update(model: T): Promise<ResponseApiModel<T>> {
    try {
      const response = await ApiConfig(this.endpoint).put<ResponseApiModel<T>>(
        "",
        model
      );
      return response.data;
    } catch (error: any) {
      if (error.response.status == 400) {
        return error.response.data;
      } else {
        var res = new ResponseApiModel<T>();
        res.errors = [];
        res.internalErrorMessage = "" + error;
        res.isInternalError = true;
        res.statusCode = 500;
        res.success = false;
        return res;
      }
    }
  }

  async delete(id: string): Promise<ResponseApiModel<T>> {
    try {
      const response = await ApiConfig(this.endpoint).delete<
        ResponseApiModel<T>
      >(`/${id}`);
      return response.data;
    } catch (error: any) {
      
      if (error.response.status == 400) {
        return error.response.data;
      } else {
        var res = new ResponseApiModel<T>();
        res.errors = [];
        res.internalErrorMessage = "" + error;
        res.isInternalError = true;
        res.statusCode = 500;
        res.success = false;
        return res;
      }
    }
  }
}

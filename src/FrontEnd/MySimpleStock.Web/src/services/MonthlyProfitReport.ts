import { MonthlyProfitReportModel } from "../types";
import { ApiConfig } from "./ApiConfig";
import { BaseService } from "./BaseService";

export class MonthlyProfitReport extends BaseService<MonthlyProfitReportModel>{

constructor() {
    super("v1/profit-reports");
}

async getByMonthAndYear(month: number,year:number): Promise<MonthlyProfitReportModel | null> {
    try {
        console.log(month)
        console.log(year)
      const response = await ApiConfig("v1/profit-reports/get-by-month-and-year").get<MonthlyProfitReportModel>(`/${month}/${year}`);
      return response.data;
    } catch (error) {
      return null;
    }
  }

}
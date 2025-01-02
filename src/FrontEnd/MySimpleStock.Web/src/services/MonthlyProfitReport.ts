import { MonthlyProfitReportModel } from "../types";
import { BaseService } from "./BaseService";

export class MonthlyProfitReport extends BaseService<MonthlyProfitReportModel>{

constructor() {
    super("v1/profit-reports");
    
}
}
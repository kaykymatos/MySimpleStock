import { MonthlyProfitReportViewModel } from "../types";
import { BaseService } from "./BaseService";

export class MonthlyProfitReport extends BaseService<MonthlyProfitReportViewModel>{

constructor() {
    super("v1/profit-reports");
    
}
}
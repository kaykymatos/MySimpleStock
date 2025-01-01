import { SaleViewModel } from "../types";
import { BaseService } from "./BaseService";

export class SaleService extends BaseService<SaleViewModel>{
    
    constructor() {
        super("v1/sales");
        
    }
}
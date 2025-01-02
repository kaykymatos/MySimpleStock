import { SaleModel } from "../types";
import { BaseService } from "./BaseService";

export class SaleService extends BaseService<SaleModel>{
    
    constructor() {
        super("v1/sales");
        
    }
}
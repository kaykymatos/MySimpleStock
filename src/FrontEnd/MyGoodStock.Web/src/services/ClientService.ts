import { ClientModel } from "../types";
import { BaseService } from "./BaseService";

export class ClientService extends BaseService<ClientModel> {
  constructor() {
    super("v1/clients");
  }
}

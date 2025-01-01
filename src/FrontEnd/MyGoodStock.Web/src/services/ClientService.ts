import { ClientViewModel } from "../types";
import { BaseService } from "./BaseService";

export class ClientService extends BaseService<ClientViewModel> {
  constructor() {
    super("v1/clients");
  }
}

import { HTTP } from "@/services/BaseAxios";

export default {
  async login(userCred) {
    return HTTP.post("/Accounts/authenticate", userCred);
  },

  async externalLogin(userExternal) {
    return HTTP.post("/Accounts/external-login", userExternal);
  },
};

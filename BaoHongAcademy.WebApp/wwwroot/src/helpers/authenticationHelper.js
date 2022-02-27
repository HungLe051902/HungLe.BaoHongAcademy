const TOKEN_KEY = "Token";

const saveToken = function(token) {
  localStorage.setItem(TOKEN_KEY, token);
};

const getToken = function() {
  localStorage.getItem(TOKEN_KEY);
};

const logout = function() {
  localStorage.clear();
};

export { saveToken, getToken, logout, TOKEN_KEY };

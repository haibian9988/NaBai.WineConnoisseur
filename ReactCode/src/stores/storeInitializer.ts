
import WineStore from './wineStore';
import UserStore from './userStore';
import SessionStore from './sessionStore';
import AuthenticationStore from './authenticationStore';
import AccountStore from './accountStore';

export default function initializeStores() {
  return {
    authenticationStore: new AuthenticationStore(),
   
    wineStore: new WineStore(),
    userStore: new UserStore(),
    sessionStore: new SessionStore(),
    accountStore: new AccountStore(),
  };
}

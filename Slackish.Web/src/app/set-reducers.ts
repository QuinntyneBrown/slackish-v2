import { getByCurrentProfileReducer } from "./conversations";
import { sendReducer } from "./messages";
import { registerReducer } from "./profiles";
import { IocContainer } from "./ioc-container";
import { Store } from "./utilities";

export function setReducers() {
    //const store = IocContainer.resolve(Store);
    //store.reducers.push(getByCurrentProfileReducer);
    //store.reducers.push(registerReducer);
    //store.reducers.push(sendReducer);
}
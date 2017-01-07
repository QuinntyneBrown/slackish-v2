import { Storage } from "./storage";
import { STORAGE_KEY, TOKEN_KEY } from "./constants";
import { Http } from "./http";
import { IocContainer } from "../ioc-container";

export var fetch = (options: { url: string, method?: string, data?: any, headers?: any, authRequired?: boolean, isObjectData?: boolean }) => {
    return new Promise(resolve => {
        var xhr = new Http();
        xhr.open(options.method || "GET", options.url, true);

        options.headers = options.headers || { "Content-Type": "application/json;charset=UTF-8" };

        if (options.authRequired)
            options.headers["Authorization"] = `Bearer ${IocContainer.resolve(Storage).get({ name: TOKEN_KEY })}`;


        for (var prop in options.headers) {
            xhr.setRequestHeader(prop, options.headers[prop]);
        }

        xhr.onload = (e) => {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    resolve(xhr.responseText);
                }
                else {
                    resolve(xhr.responseText);
                }
            }
        };

        if (!options.isObjectData && typeof options.data != "string") {
            options.data = JSON.stringify(options.data);
        }

        xhr.send(options.data);
    });
}


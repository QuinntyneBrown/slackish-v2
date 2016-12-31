export const addOrUpdate = (options: { items: Array<any>, item: any, key?: string; }) => {
    let exists = false;
    options.items = options.items || [];
    for (let i = 0; i < options.items.length; i++) {
        if (options.items[i][options.key || "id"] === options.item[options.key || "id"]) {
            options.items[i] = options.item;
            exists = true;
        }
    }
    if (!exists) { options.items.push(options.item); }
}
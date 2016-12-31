export const pluck = <T>(options: { items: Array<any>; value: any; key?: string; }): T => {
    var item = {};
    for (var i = 0; i < options.items.length; i++) {
        if (options.value == options.items[i][options.key || "id"]) { item = Object.assign({}, options.items[i]); }
    }
    return item as T;
};
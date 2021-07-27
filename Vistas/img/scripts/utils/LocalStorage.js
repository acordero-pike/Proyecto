const LocalStorage  = {
    get(storageKey){
        //localStorage.getItem(storageKey);
        return 1;
    },
    set(storageKey, value){
        localStorage.setItem(storageKey, value);
    }
}

export default LocalStorage;
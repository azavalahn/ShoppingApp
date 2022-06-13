import { useEffect, useState } from "react"
import { getEmployeeTypes } from "../helpers/getEmployeeTypes";

export const useFetchEmployeeTypes = () => {
    const [state, setState] = useState({
        data: [],
        loading: true
    });

    useEffect(() => {
        getEmployeeTypes()
            .then(e => {
                setState({
                    data: e,
                    loading: false
                });
            })
    }, []);




    return state;
}
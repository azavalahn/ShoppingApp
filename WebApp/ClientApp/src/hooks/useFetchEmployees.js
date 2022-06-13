import { useEffect, useState } from "react"
import { getEmployees } from "../helpers/getEmployees";

export const useFetchEmployees = () => {
    const [state, setState] = useState({
        data: [],
        loading: true
    });

    useEffect(() => {
        getEmployees()
            .then(e => {
                setState({
                    data: e,
                    loading: false
                });
            })
    }, []);
    return state;
}
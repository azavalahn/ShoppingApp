import React, { useState, useEffect } from 'react';
import { useFetchEmployeeTypes } from '../hooks/useFetchEmployeeTypes';
import { postEmployee } from '../helpers/postEmployee';

export const EmployeeRegistration = () => {

    
    const { data, loading } = useFetchEmployeeTypes();
    const [temp, setTemp] = useState("");
    const [state, setState] = useState({
        employeeName: "",
        employeeType: "",
        telephone: "",
        address: "",
        employmentDate: ""
    })

    useEffect(() => {
        data.map((e, i) => {
            if (i == 0) {
                setState({
                    ...state,
                    ['employeeType']: e.id
                });
                setTemp(e.id);
            }
        })
    }, [data])


    const handleChange = (e) => {
        const value = e.target.value;
        console.log('values es', value);
        console.log('name es', e.target.name);
        
        setState({
            ...state,
            [e.target.name]: value
        });
    }

    const handleSave = () => {
        if (state.employeeName && state.telephone && state.employmentDate) {
            const payload = {
                name: state.employeeName,
                employeeTypeId: state.employeeType,
                telephone: state.telephone,
                address: state.address,
                employmentDate: state.employmentDate
            }

            postEmployee(payload);
            alert('Employeed has been registered successfuly');
        }
        else {
            alert("ERROR ! Please fill up all required fields marked with a *");
        }
    }
    
    console.log('Data es', data);
    return (
            <>
            <h1>Employee Registration</h1>
            
            <div className="input-group mb-3">
                <div className="input-group-prepend">
                    <span className="input-group-text" id="basic-addon1">Employee Name *</span>
                </div>
                <input type="text" name="employeeName" value={state.employeeName} onChange={ handleChange } className="form-control" placeholder="Employee Name" aria-label="Employee Name" aria-describedby="basic-addon1" />
            </div>
            <div className="input-group mb-3">
                <div className="input-group-prepend">
                    <span className="input-group-text" id="basic-addon1">Employee Type</span>
                </div>
                <select name="employeeType" value={state.employeeType} onChange={ handleChange} name="employeeType">
                    {
                        data.map((e, i) => (
                            <option value={e.id}>{e.name}</option>
                        ))
                    }
                </select>
            </div>
            <div className="input-group mb-3">
                <div className="input-group-prepend">
                    <span className="input-group-text" id="basic-addon1">Telephone *</span>
                </div>
                <input type="text" name="telephone" value={state.telephone} onChange={handleChange} className="form-control" placeholder="Telephone" aria-label="Telephone" aria-describedby="basic-addon1" />
            </div>
            <div className="input-group mb-3">
                <div className="input-group-prepend">
                    <span className="input-group-text" id="basic-addon1">Address</span>
                </div>
                <input type="text" name="address" value={state.address} onChange={handleChange} className="form-control" placeholder="Address" aria-label="Address" aria-describedby="basic-addon1" />
            </div>
            <div className="input-group mb-3">
                <div className="input-group-prepend">
                    <span className="input-group-text" id="basic-addon1">Employment Date *</span>
                </div>
                <input type="datetime-local" name="employmentDate" value={state.employmentDate} onChange={handleChange} />
            </div>

            <button className="btn btn-primary" onClick={handleSave}>Register Employee</button>
            </>
    )
}
import React from 'react';
import { useFetchEmployees } from '../hooks/useFetchEmployees';


export const EmployeeGrid = () => {
    
    const { data, loading } = useFetchEmployees();

    return (
        <>
          <h1> Employee List </h1>

            <table className='table table-striped' aria-labelledby="tabelLabel">
                <tr>
                  <th>Employee Name</th>
                  <th>Employee Type(C)</th>
                  <th>Telephone</th>
                  <th>Address</th>
                  <th>Employment Date</th>
                 </tr>
                {                    
                   data.map(e => (
                        <tr key={e.employeeName}>
                            <td>{e.employeeName}</td>
                            <td>{e.employeeTypeName}</td>
                            <td>{e.telephone}</td>
                            <td>{e.address}</td>
                            <td>{e.employmentDate}</td>
                        </tr>
                        ))

                 }
                  
            </table>
        </>
    )
}


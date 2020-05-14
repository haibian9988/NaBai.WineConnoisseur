import * as React from 'react';

import { Col, Row } from 'antd';

export class About extends React.Component<any> {
  render() {
    return (
      <Row>
        <Col>
          <div>
            <div>
                        <h2>[Problem Statement]</h2>
            </div>
            <div>
              <p>
               Develop a pseudo full stack application for listing different wines. Your webapp is supposed to 
             be an aggregator which lists different kind of wines
                             .
              </p>

               <h3>[Minimum Requirement]</h3>

                        <p>
              Use of the data dump provided. Put this dump in a database.
                            Implement a frontend and a backend in the tech stack mentioned below.
                            Expose APIs from your backend which should be consumed by your frontend.
                            Visually attractive and responsive design listing all the wine details.
                            Zip all your source code, Deployment Instructions, Executables, Dump files and upload.
              </p>

                        <p> <h3>[Plus Point]</h3>
             Implement a feature to filter wines based on different country, province, regions.
             Implement a feature to filter wines based on different type of grapes used.
             Implement a feature to sort the wines based on the price.
             Zip all your source code, Deployment Instructions, Executables, Dump files and upload
              </p>

                        <h3>[Advanced]</h3>

              <p>
               database.
              Custom elegant design, fonts and icons to make web app more user-friendly.
              You may add portfolio activity comprising awesome work you have done on web 
             application(s).
              Use your imagination and add features which would make things easier for end users.
              </p>
        

           <h3>[Tech Stack]</h3>

              <p>
               Frontend: HTML5, React, Vue, JavaScript, Bootstrap, JSON, CSS
             Backend: any
              </p>
            </div>
          </div>
        </Col>
      </Row>
    );
  }
}
export default About;

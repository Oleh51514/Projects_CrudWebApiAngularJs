﻿/*! Auto-generated. This file was generated by Nca.Valdr. */

app.config(["valdrProvider",
    function config(valdrProvider) {
        valdrProvider.addConstraints({
            // page "inviteUser"
            "employee": {
                "firstName": {
                    "required": {
                        "message": "first name required"
                    }
                },
                "lastName": {
                    "required": {
                        "message": "last name required"
                    }
                },
                "age": {
                    "required": {
                        "message": "age required"
                    }
                }
            },
            // page "timeFrameModal"
            "department": {
                "name": {
                    "required": {
                        "message": "name required"
                    }
                },
                "description": {
                    "required": {
                        "message": "description required"
                    }
                },
                "date": {
                    "required": {
                        "message": "date required"
                    }
                }     
            }
        });
    }]);

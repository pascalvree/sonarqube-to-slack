# sonarqube-to-slack

Purpose:
  retrieve Sonarqube measurements using their WebAPI and pushing a simple Message into a Slack-channel.

Sonarqube Json Message:
[{
    "id": null,
    "key": "",
    "name": "",
    "scope": "",
    "qualifier": "",
    "date": "",
    "creationDate": "",
    "lname": "",
    "version": "",
    "branch": "",
    "description": "",
    "msr": [{
        "key": "",
        "val": null,
        "frmt_val": ""
    }]
}]

Slack Json Message format:
{
  text: "..."
}

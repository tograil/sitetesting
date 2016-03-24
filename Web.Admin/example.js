var currentUser = {
	name: 'Mary'
}

/**
* @api {get} /user Request User information
* @apiName GetUser
* @apiGroup User
*/
function getUser() {
	return { code: 200, data: currentUser };
}

function setName(name) {
	if(name.length===0)	{
		return { code: 404, message: 'NameEmptyError' }
	}
	
	currentUser.name = name;
	
	return { code: 204 };
}

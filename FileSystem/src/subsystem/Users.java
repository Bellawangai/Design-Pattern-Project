package subsystem;

import java.util.Hashtable;

public class Users {
	private String username;
	private Hashtable<String, Direction> userlist = new Hashtable<String, Direction>();
    private static Users inst=new Users();
	private Users(){
		
	}
	
	public static synchronized Users getInstance(){
		return inst;
	}
	
	public void addUser(Direction a) {
		this.userlist.put(a.getName(), a);
	}
	
	public boolean whetherExist(String username){
		return userlist.containsKey(username);
	}
	
    public Direction getUserDir(String username){
    	return this.userlist.get(username);
    }
    
	public String getUsername() {
		return username;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public Hashtable<String, Direction> getUserlist() {
		return userlist;
	}

	public void setUserlist(Hashtable<String, Direction> userlist) {
		this.userlist = userlist;
	}
}

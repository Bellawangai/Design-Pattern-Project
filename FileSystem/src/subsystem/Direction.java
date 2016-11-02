package subsystem;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.Map.Entry;

public class Direction implements Serializable{
	private static final long serialVersionUID = 1L;
	/*目录名*/
	private String name;
	/*父目录 */
	private Direction fatherDir;
	/*该目录下目录列表*/
	private Hashtable<String, Direction> dirlist = new Hashtable<String, Direction>();
	/*该目录下文件列表*/
	private Hashtable<String, File> filelist = new Hashtable<String, File>();
	/*该目录大小*/
	private int oldsize;
	private int newsize;
	/*记录该目录所占用的磁盘块序号*/
	private ArrayList<Integer> usedblock = new ArrayList<Integer>();
    /*记录该目录所占用的新的磁盘块序号*/
    
	public ArrayList<Integer> getUsedblock() {
		return usedblock;
	}
	   
	 public static Object cloneObject(Object obj){
	     Object objx=null;
		 try{
	    	 ByteArrayOutputStream  byteOut = new ByteArrayOutputStream();  
		        ObjectOutputStream out = new ObjectOutputStream(byteOut);  
		        out.writeObject(obj);         
		        ByteArrayInputStream byteIn = new ByteArrayInputStream(byteOut.toByteArray());  
		        ObjectInputStream in =new ObjectInputStream(byteIn);  
		        objx=in.readObject();
		        
	     }catch (Exception e) {
	    	 System.out.println("目录拷贝时发生错误，请重新拷贝");
		}
		 return objx;
		
	}
    /*判断能否粘贴该目录*/
    public boolean canPasteDir(Direction a){
    	return !dirlist.containsKey(a.getName());
    }
    /*判断能否粘贴该文件*/
    public boolean canPasteFile(File a){
    	return !filelist.containsKey(a.getName());
    }   
    
	public void setUsedblock(ArrayList<Integer> usedblock) {
		this.usedblock = usedblock;
	}
	
	public void removeold(ArrayList<Integer> all){
		for(Integer a:all){
			if (usedblock.contains(a))
			usedblock.remove(a);
		}
	}
	
	/*在目录下增加磁盘块号*/
	public void addnew(ArrayList<Integer> all){
		for(Integer a:all){
			usedblock.add(a);
		}
	}
	/*更新目录的大小*/
	public void updateSize(){
		this.newsize=DiskBlock.getSize()*usedblock.size();
	}

	public int getOldsize() {
		return oldsize;
	}

	public void setOldsize(int oldsize) {
		this.oldsize = oldsize;
	}

	public int getNewsize() {
		return newsize;
	}

	public void setNewsize(int newsize) {
		this.newsize = newsize;
	}

	public Direction() {

	}

	public Direction(String name) {
		this.name = name;
	}

	public Direction(String name, int old, int tnew) {
		this(name);
		this.newsize = tnew;
		this.oldsize = old;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Direction getFatherDir() {
		return fatherDir;
	}

	public void setFatherDir(Direction fatherDir) {
		this.fatherDir = fatherDir;

	}

	/*显示目录下所有文件和目录 */
	public void ls() {
		int count = 0;
		Iterator<String> a = filelist.keySet().iterator();
		while (a.hasNext()) {
			File inst = filelist.get(a.next());
			System.out.print(inst.getName() + "(文件)---大小:" + inst.getNewsize()
					+ "     ");
			count++;
		}
		Iterator<String> b = dirlist.keySet().iterator();
		while (b.hasNext()) {
			Direction inst = dirlist.get(b.next());
			System.out.print(inst.getName() + "(目录)---大小:" + inst.getNewsize()
					+ "     ");
			count++;
		}
		if (count == 0)
			System.out.println("对不起，当前目录下并无文件");
		else
			System.out.println();
	}

	/*跳转目录*/
	public Direction cd(String name) {

		return dirlist.get(name);
	}

	public Direction cdReturn() {
		return fatherDir;
	}

	//根据目录名得到该目录
	//oldname目录名，为String型
	public Direction getDir(String oldname) {
		return dirlist.get(oldname);
	}

	/*添加目录*/
	public void addDir(Direction a) {
		if(dirlist.containsKey(a.getName()))
		     System.out.println("已经存在同名目录，操作失败");
		else dirlist.put(a.getName(), a);
	}

	/*删除目录dirname，为String型*/
	public void deleteDir(String dirname) {
		dirlist.remove(dirname);
	}

	//根据文件名得到该文件
	//filename文件名，为String型
	public File getFile(String filename) {
		return filelist.get(filename);
	}

	//增加一个文件
	//filename文件名，为String型
	public void addFile(File a) {
		if(filelist.containsKey(a.getName()))
				System.out.println("对不起，该目录下已经存在同名文件，操作失败");
		else filelist.put(a.getName(), a);
	}

	//删除文件
	//filename文件名，为String型
	public void deleteFile(String filename) {
		filelist.remove(filename);
	}
}

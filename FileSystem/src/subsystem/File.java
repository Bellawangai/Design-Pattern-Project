package subsystem;

import java.io.Serializable;
import java.util.ArrayList;

public class File implements Serializable{
	
	private static final long serialVersionUID = 1L;
	private int oldsize;        //修改前文件大小
	private int newsize;        //修改后文件大小

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

	private String name;        //保存文件名字

	public File() {

	}

	public File(String name) {
		this.name = name;
	}

	public File(String name, int old, int tnew) {
		this(name);
		this.oldsize = old;
		this.newsize = tnew;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	private ArrayList<DiskBlock> blocklist = new ArrayList<DiskBlock>();

	public ArrayList<DiskBlock> getBlocklist() {
		return blocklist;
	}

	public void setBlocklist(ArrayList<DiskBlock> blocklist) {
		this.blocklist = blocklist;
	}

	public void clearBlocklist() {
		this.blocklist.clear();
	}

	//一个文件较大，添加磁盘块以保存该文件内容
	//a为要添加到文件磁盘列表的磁盘块号
	public void addBlock(DiskBlock a) {
		this.blocklist.add(a);
	}
}
